using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tombala
{
    class Oyuncu
    {
        public int oyuncuNo;
        public string isim;
        public int kartNo;
        public int tombalaCount;
        public int cinkoBirCount;
        public int cinkoIkiCount;
        public int totalPoint;
        public bool cinkoBirKontrol = false;
        public bool cinkoIkiKontrol = false;
        public bool tombalaKontrol = false;
    }
}
