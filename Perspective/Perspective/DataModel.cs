using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perspective
{
    public class DataModel
    {
        private List<ChapterPOVs> m_chapterList = new List<ChapterPOVs>();
        private HashSet<PointOfView> m_uniquePOVs = new HashSet<PointOfView>();

        public DataModel(string perspectiveList)
        {
            foreach (string byChapter in perspectiveList.Split(';'))
            {
                m_chapterList.Add(new ChapterPOVs(byChapter));
            }

            GenerateUniquePOVList();
        }

        /// <summary>
        /// Returns a unique list of POVs
        /// </summary>
        /// <returns></returns>
        public void GenerateUniquePOVList()
        {
            foreach (ChapterPOVs cPOVs in m_chapterList)
            {
                foreach (PointOfView pv in cPOVs)
                {
                    m_uniquePOVs.Add(pv);
                }
            }
        }

        public HashSet<PointOfView> GetUniquePOVs()
        {
            return m_uniquePOVs;
        }

        public int GetChapterCount()
        {
            return m_chapterList.Count();
        }

        public List<ChapterPOVs> GetChapters()
        {
            return m_chapterList;
        }

        public int GetMaxSceneCount()
        {
            int rValue = 0;

            foreach (ChapterPOVs povs in m_chapterList)
            {
                int cnt = povs.GetPOVCount();
                if (rValue < cnt)
                    rValue = cnt;
            }

            return rValue;
        }
            

    }

    public class PointOfView : IEquatable<PointOfView>
    {
        private string m_characterName;

        public PointOfView()
        {

        }

        public PointOfView(string name)
        {
            m_characterName = name;
        }

        public string GetName()
        {
            return m_characterName;
        }

        public bool Equals(PointOfView other)
        {
            return this.m_characterName.Equals(other.GetName());
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }
    }

    public class ChapterPOVs : IEnumerable
    {
        private PointOfView[] m_povs;

        /// <summary>
        /// Passed a comma-separated list of character names representing a chapter, builds it into PointOfView[].
        /// </summary>
        /// <param name="commaSeparatedString"></param>
        public ChapterPOVs(string commaSeparatedString)
        {

            string[] separated = commaSeparatedString.Trim().Split(',');
            m_povs = new PointOfView[separated.Length];

            for (int i = 0; i < separated.Length; i++)
            {
                m_povs[i] = new PointOfView(separated[i].Trim());
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public POVEnum GetEnumerator()
        {
            return new POVEnum(m_povs);
        }

        public int GetPOVCount()
        {
            return m_povs.Length;
        }
    }

    public class POVEnum : IEnumerator
    {
        public PointOfView[] m_povs;

        int position = -1;

        public POVEnum(PointOfView[] list)
        {
            m_povs = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < m_povs.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public PointOfView Current
        {
            get
            {
                try
                {
                    return m_povs[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}