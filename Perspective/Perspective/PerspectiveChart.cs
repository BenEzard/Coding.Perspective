using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perspective
{
    class PerspectiveChart
    {
        private Image m_tempImage = null;
        private Graphics m_tempCanvas = null;

        private static int DEFAULT_MARGIN = 5;
        private static int DEFAULT_GAP = 5;
        private static int DEFAULT_PADDING = 5;


        private Font m_normalFont = new Font(SystemFonts.DefaultFont.FontFamily, 10, FontStyle.Regular);
        private Font m_titleFont = new Font(SystemFonts.DefaultFont.FontFamily, 18, FontStyle.Bold);
        private Font m_subTitleFont = new Font(SystemFonts.DefaultFont.FontFamily, 14, FontStyle.Regular);

        private Font m_normalCellFont = null;

        private DataModel m_data = null;

        private string m_title;
        private string m_subTitle;

        private Dictionary<string, PointOfViewChartObject> m_povs = new Dictionary<string, PointOfViewChartObject>();
        private int m_chapterCount = -1;
        private int m_maxSceneCount = -1;
        private SizeF m_cellSize;
        private Size m_imageSize;
        private SizeF m_titleSize;
        private SizeF m_subTitleSize;
        private SizeF m_allTitlesSize;

        private Color m_normalCellBackground { set; get; }
        private Color m_normalCellForeground = Color.Black;
        public int CELL_BORDER_WIDTH { set; get; }
        private bool m_blankCellPaint = true;
        private Color m_blankCellBackground { set; get; }

        private Dictionary<ChartProperties, int> m_measurements = new Dictionary<ChartProperties, int>();

        public PerspectiveChart(DataModel data, string title, string subTitle)
        {
            // Initialise the class variables
            m_tempImage = new Bitmap(1, 1);
            m_tempCanvas = Graphics.FromImage(m_tempImage);
            m_title = title;
            m_subTitle = subTitle;

            m_data = data;
        }

        public void initialise()
        {
            foreach (ChartProperties p in Enum.GetValues(typeof(ChartProperties)))
            {
                Console.WriteLine(p+" = "+p.GetTypeCode()+" = "+p.GetHashCode());
            }

            SetDefaultValues();
            CreatePointOfViewChartObjects();

            // -- Calculate stats -------------------------------------------------------------------------
            m_chapterCount = m_data.GetChapterCount();
            m_maxSceneCount = m_data.GetMaxSceneCount();

            SizeF maxPointOfViewDimensions = GetMaxPointOfViewDimensions();

            // -- Determine how big each cell should be ----
            // This is the max(textSize) + 2x horizontal spacing + 2x border width
            float cellWidth = maxPointOfViewDimensions.Width + (2 * m_measurements[ChartProperties.CELL_HORIZONTAL_PADDING]); // + 2x border
            float cellHeight = maxPointOfViewDimensions.Height + (2 * m_measurements[ChartProperties.CELL_VERTICAL_PADDING]); // + 2x border
            m_cellSize = new SizeF(cellWidth, cellHeight);

            // -- Determine how wide the image should be ----
            m_imageSize = CalculateImageSize();

            // Clear memory of items no longer needed.
            m_tempImage.Dispose();
            m_tempCanvas.Dispose();
        }

        public void SetNormalCellStyle(Color backgroundColor, Color textColor, Font font)
        {
            m_normalCellBackground = backgroundColor;
            m_normalCellForeground = textColor;
            m_normalCellFont = font;
        }

        public void SetCellSpacing(int horizontalGap, int verticalGap, int horizontalPadding, int verticalPadding)
        {
            m_measurements[ChartProperties.CELL_HORIZONTAL_GAP] = horizontalGap;
            m_measurements[ChartProperties.CELL_VERTICAL_GAP] = verticalGap;
            m_measurements[ChartProperties.CELL_HORIZONTAL_PADDING] = horizontalPadding;
            m_measurements[ChartProperties.CELL_VERTICAL_PADDING] = verticalPadding;
        }

        public void SetTitles(string title, string subTitle)
        {
            m_title = title.Trim();
            m_subTitle = subTitle.Trim();

            if (m_title.Length == 0)
                m_title = null;
            if (m_subTitle.Length == 0)
                m_subTitle = null;
        }

        public void SetImageMargins(int left, int top, int right, int bottom)
        {
            m_measurements[ChartProperties.IMAGE_MARGIN_LEFT] = left;
            m_measurements[ChartProperties.IMAGE_MARGIN_TOP] = top;
            m_measurements[ChartProperties.IMAGE_MARGIN_RIGHT] = right;
            m_measurements[ChartProperties.IMAGE_MARGIN_BOTTOM] = bottom;
        }

        public void SetDefaultValues()
        {
            m_measurements.Add(ChartProperties.IMAGE_MARGIN_LEFT, DEFAULT_MARGIN);
            m_measurements.Add(ChartProperties.IMAGE_MARGIN_TOP, DEFAULT_MARGIN);
            m_measurements.Add(ChartProperties.IMAGE_MARGIN_RIGHT, DEFAULT_MARGIN);
            m_measurements.Add(ChartProperties.IMAGE_MARGIN_BOTTOM, DEFAULT_MARGIN);
            m_measurements.Add(ChartProperties.CELL_BORDER_WIDTH, 1); // todo set
            m_measurements.Add(ChartProperties.CELL_HORIZONTAL_GAP, DEFAULT_GAP);
            m_measurements.Add(ChartProperties.CELL_VERTICAL_GAP, DEFAULT_GAP);
            m_measurements.Add(ChartProperties.CELL_HORIZONTAL_PADDING, DEFAULT_PADDING);
            m_measurements.Add(ChartProperties.CELL_VERTICAL_PADDING, DEFAULT_PADDING);

        }

        public void BlankCellPainting(bool paint, Color backgroundColor)
        {
            m_blankCellPaint = paint;
            m_blankCellBackground = backgroundColor;
        }

        private SizeF CalculateStringSize(string str, Font font)
        {
            SizeF rValue = new Size(0, 0);

            if ((str != null) && (str.Length > 0))
                rValue = m_tempCanvas.MeasureString(str, font);

            return rValue;
        }

        private Size CalculateImageSize()
        {
            // --- Calculate title size -----------------------------------------------------------------------
            // Title height is the Title Height + Cell Vertical Gap + Sub Title Height
            // Title width is the greater of Title or SubTitle width.

            if (m_title != null)
                m_titleSize = m_tempCanvas.MeasureString(m_title, m_titleFont);
            if (m_subTitle != null)
                m_subTitleSize = m_tempCanvas.MeasureString(m_subTitle, m_subTitleFont);

            m_allTitlesSize = new SizeF(m_titleSize.Width > m_subTitleSize.Width ? m_titleSize.Width : m_subTitleSize.Width,
                m_titleSize.Height + m_measurements[ChartProperties.CELL_VERTICAL_GAP] + m_subTitleSize.Height);

            // --- Calculate image height ---------------------------------------------------------------------
            float imageHeight = m_measurements[ChartProperties.IMAGE_MARGIN_TOP] + m_measurements[ChartProperties.IMAGE_MARGIN_BOTTOM];
            imageHeight += (m_chapterCount * m_cellSize.Height);
            imageHeight += (m_chapterCount * m_measurements[ChartProperties.CELL_VERTICAL_GAP]) + m_measurements[ChartProperties.CELL_VERTICAL_GAP];

            imageHeight += m_allTitlesSize.Height;

            // --- Calculate image height ---------------------------------------------------------------------
            float imageWidth = (m_maxSceneCount * m_cellSize.Width) + (2 * m_maxSceneCount * m_measurements[ChartProperties.CELL_HORIZONTAL_GAP]) + (2 * m_maxSceneCount * m_measurements[ChartProperties.CELL_HORIZONTAL_GAP]); // + row header width
            imageWidth += m_measurements[ChartProperties.IMAGE_MARGIN_LEFT] + m_measurements[ChartProperties.IMAGE_MARGIN_RIGHT];

            if (m_allTitlesSize.Width > imageWidth)
                imageWidth = m_allTitlesSize.Width;

            return new Size((int)imageWidth, (int)imageHeight);
        }

        public Image DrawImage()
        {
            Image img = new Bitmap(m_imageSize.Width, m_imageSize.Height);
            Graphics drawing = Graphics.FromImage(img);
            drawing = Graphics.FromImage(img);
            

            //paint the background
            drawing.Clear(Color.AntiqueWhite);

            //create a brush for the text
            Brush textBrush = new SolidBrush(Color.Black);

            Pen pen = new Pen(Color.Black, (float)0.2);
            SolidBrush normalCellFontBrush = new SolidBrush(m_normalCellForeground);
            //SolidBrush cellNormalBrush = new SolidBrush(Color.FromArgb(153,204,255));
            SolidBrush cellNormalBrush = new SolidBrush(m_normalCellBackground);
            SolidBrush blankCellBrush = new SolidBrush(m_blankCellBackground);

            // --- Draw Title and SubTitle --------------------------------------------------------------------
            Point xy = new Point(m_measurements[ChartProperties.IMAGE_MARGIN_LEFT], m_measurements[ChartProperties.IMAGE_MARGIN_TOP]);
            if (m_title != null)
            {
                drawing.DrawString(m_title, m_titleFont, normalCellFontBrush, xy);
                xy.Y += (int)m_titleSize.Height;
            }
            if (m_subTitle != null)
            {
                drawing.DrawString(m_subTitle, m_subTitleFont, normalCellFontBrush, new Point(0, (int)m_titleSize.Height + m_measurements[ChartProperties.CELL_VERTICAL_GAP]));
                xy.Y += (int)m_subTitleSize.Height + m_measurements[ChartProperties.CELL_VERTICAL_GAP];
            }

            foreach (ChapterPOVs cPOVs in m_data.GetChapters())
            {
                for (int povCounter = 0; povCounter < m_maxSceneCount; ++povCounter)
//                foreach (PointOfView pov in cPOVs)
                {
                    PointOfView pov = cPOVs.GetPOV(povCounter);

                    if (pov != null)
                    {
                        //drawing.DrawRectangle(pen, new Rectangle(xy.X, xy.Y, (int)m_cellSize.Width, (int)m_cellSize.Height));
                        drawing.FillRectangle(cellNormalBrush, new Rectangle(xy.X, xy.Y, (int)m_cellSize.Width, (int)m_cellSize.Height));
                        PointOfViewChartObject povco;
                        m_povs.TryGetValue(pov.GetName(), out povco);
                        int xWritingPosition = (int)(m_cellSize.Width - povco.GetSize().Width) / 2;
                        int yWritingPosition = (int)(m_cellSize.Height - povco.GetSize().Height) / 2;
                        // Get PovChartObject from pov
                        drawing.DrawString(pov.GetName(), m_normalCellFont, normalCellFontBrush, new Point(xy.X + xWritingPosition, xy.Y + yWritingPosition));
                    } else
                    {
                        if (m_blankCellPaint)
                            drawing.FillRectangle(blankCellBrush, new Rectangle(xy.X, xy.Y, (int)m_cellSize.Width, (int)m_cellSize.Height));
                    }



                    xy.X += m_measurements[ChartProperties.CELL_HORIZONTAL_GAP] + (int)m_cellSize.Width;
                }
                xy.Y += m_measurements[ChartProperties.CELL_VERTICAL_GAP] + (int)m_cellSize.Height;
                xy.X = m_measurements[ChartProperties.CELL_VERTICAL_GAP];
            }


            //drawing.DrawString("Captain Yates", font, textBrush, 0, 0);

            drawing.Save();
            img.Save(@"D:\Development\GitHub\Coding.Perspective\Output\test.png", ImageFormat.Png);
            
            textBrush.Dispose();
            drawing.Dispose();

            return img;
        }

        private void CreatePointOfViewChartObjects()
        {
            foreach (PointOfView pov in m_data.GetUniquePOVs())
            {
                Font font = new Font(SystemFonts.DefaultFont.FontFamily, 10, FontStyle.Regular);
                SizeF m_textSize = m_tempCanvas.MeasureString(pov.GetName(), font);

                m_povs.Add(pov.GetName(), new PointOfViewChartObject(pov, m_textSize));
            }
        }

        /// <summary>
        /// Returns the largest dimensions (width and height) for the PointOfViewChartObjects loaded.
        /// Note that the width and height may not relate to the same PointOfViewChartObject.
        /// </summary>
        /// <returns></returns>
        private SizeF GetMaxPointOfViewDimensions()
        {
            SizeF rValue = new SizeF(0, 0);

            foreach (string key in m_povs.Keys)
            {
                PointOfViewChartObject povco;
                m_povs.TryGetValue(key, out povco);
                if (rValue == null)
                    rValue = povco.GetSize();
                if (rValue.Height < povco.GetSize().Height)
                    rValue.Height = povco.GetSize().Height;
                if (rValue.Width < povco.GetSize().Width)
                    rValue.Width = povco.GetSize().Width;
            }
            return rValue;
        }

        public void DebugPointOfViewObjects()
        {
            foreach (string key in m_povs.Keys)
            {
                PointOfViewChartObject povco;
                m_povs.TryGetValue(key, out povco);
                Console.WriteLine(povco.GetName() + " : " + povco.GetSize().ToString());
            }
        }

    }

    public enum ChartProperties
    {
        IMAGE_MARGIN_LEFT,
        IMAGE_MARGIN_TOP,
        IMAGE_MARGIN_RIGHT,
        IMAGE_MARGIN_BOTTOM,
        CELL_BORDER_WIDTH,
        CELL_HORIZONTAL_GAP,
        CELL_VERTICAL_GAP,
        CELL_HORIZONTAL_PADDING,
        CELL_VERTICAL_PADDING,
    }

    public class PointOfViewChartObject : PointOfView
    {
        private SizeF m_textSize;

        public PointOfViewChartObject(PointOfView pov, SizeF textSize) : base(pov.GetName())
        {
//            m_name = pov.GetName();
            m_textSize = textSize;
        }

        public SizeF GetSize()
        {
            return m_textSize;
        }

    }

}
