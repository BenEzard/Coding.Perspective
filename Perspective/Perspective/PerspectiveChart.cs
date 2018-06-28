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

        private DataModel m_data = null;

        private Dictionary<string, PointOfViewChartObject> m_povs = new Dictionary<string, PointOfViewChartObject>();
        private int m_chapterCount = -1;
        private int m_maxSceneCount = -1;
        private SizeF m_cellSize;
        private Size m_imageSize;

        public Color CELL_BACKGROUND_COLOR { set; get; }
        public int CELL_BORDER_WIDTH { set; get; }
        public int CELL_HORIZONTAL_GAP { set; get; }
        public int CELL_HORIZONTAL_SPACING { set; get; }
        public int CELL_VERTICAL_GAP { set; get; }
        public int CELL_VERTICAL_SPACING { set; get; }

        public PerspectiveChart(DataModel data)
        {
            // Initialise the class variables
            m_tempImage = new Bitmap(1, 1);
            m_tempCanvas = Graphics.FromImage(m_tempImage);

            m_data = data;
        }

        public void initialise()
        {

            CreatePointOfViewChartObjects();

            // -- Calculate stats -------------------------------------------------------------------------
            m_chapterCount = m_data.GetChapterCount();
            Console.WriteLine("chapter count = " + m_chapterCount);
            m_maxSceneCount = m_data.GetMaxSceneCount();
            Console.WriteLine("max scene count = " + m_maxSceneCount);

            SizeF maxPointOfViewDimensions = GetMaxPointOfViewDimensions();
            Console.WriteLine("max POV Height= " + maxPointOfViewDimensions.Height);
            Console.WriteLine("max POV Width= " + maxPointOfViewDimensions.Width);

            // -- Determine how big each cell should be ----
            // This is the max(textSize) + 2x horizontal spacing + 2x border width
            float cellWidth = maxPointOfViewDimensions.Width + (2 * CELL_HORIZONTAL_SPACING); // + 2x border
            float cellHeight = maxPointOfViewDimensions.Height + (2 * CELL_VERTICAL_SPACING); // + 2x border
            m_cellSize = new SizeF(cellWidth, cellHeight);

            // -- Determine how wide the image should be ----
            // Image width = row header width + (2x number of scenes as horizontal gap)
            float imageWidth = (m_maxSceneCount * m_cellSize.Width) + (2 * m_maxSceneCount * CELL_HORIZONTAL_GAP) + (2 * m_maxSceneCount * CELL_HORIZONTAL_SPACING); // + row header width
            m_imageSize = new Size((int)imageWidth, CalculateImageHeight());

            // Clear memory of items no longer needed.
            m_tempImage.Dispose();
            m_tempCanvas.Dispose();
        }

        private int CalculateImageHeight()
        {
            float imageHeight = (m_chapterCount * m_cellSize.Height);
            imageHeight += (m_chapterCount * CELL_VERTICAL_GAP) + CELL_VERTICAL_GAP;

            return (int)imageHeight;
        }

        public void DrawImage()
        {
            Image img = new Bitmap(m_imageSize.Width, m_imageSize.Height);
            Graphics drawing = Graphics.FromImage(img);
            drawing = Graphics.FromImage(img);

            //paint the background
            drawing.Clear(Color.AntiqueWhite);

            //create a brush for the text
            Brush textBrush = new SolidBrush(Color.Black);

            Font font = new Font(SystemFonts.DefaultFont.FontFamily, 10, FontStyle.Regular);

            Pen pen = new Pen(Color.Black, (float)0.2);
            SolidBrush shadowBrush = new SolidBrush(Color.Black);
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(153,204,255));
            Point xy = new Point(CELL_VERTICAL_GAP, CELL_HORIZONTAL_GAP);
            foreach (ChapterPOVs cPOVs in m_data.GetChapters())
            {
                foreach (PointOfView pov in cPOVs)
                {
                    //drawing.DrawRectangle(pen, new Rectangle(xy.X, xy.Y, (int)m_cellSize.Width, (int)m_cellSize.Height));
                    drawing.FillRectangle(blueBrush, new Rectangle(xy.X, xy.Y, (int)m_cellSize.Width, (int)m_cellSize.Height));
                    PointOfViewChartObject povco;
                    m_povs.TryGetValue(pov.GetName(), out povco);
                    int xWritingPosition = (int)(m_cellSize.Width - povco.GetSize().Width) / 2;
                    int yWritingPosition = (int)(m_cellSize.Height - povco.GetSize().Height) / 2;
                    // Get PovChartObject from pov
                    drawing.DrawString(pov.GetName(), font, shadowBrush, new Point(xy.X + xWritingPosition, xy.Y + yWritingPosition));

                    xy.X += CELL_HORIZONTAL_GAP + (int)m_cellSize.Width;
                }
                xy.Y += CELL_VERTICAL_GAP + (int)m_cellSize.Height;
                xy.X = CELL_VERTICAL_GAP;
            }


            //drawing.DrawString("Captain Yates", font, textBrush, 0, 0);

            drawing.Save();
            img.Save(@"D:\Development\GitHub\Coding.Perspective\Output\test.png", ImageFormat.Png);

            textBrush.Dispose();
            drawing.Dispose();
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
