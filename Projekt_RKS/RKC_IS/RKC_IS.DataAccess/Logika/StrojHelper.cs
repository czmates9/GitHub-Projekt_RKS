using RKC_IS.DataAccess.Model.AutoMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RKC_IS.DataAccess.Logika
{
    public class StrojHelper 
    {
        private ConnectionMap_RKC_Database db = new ConnectionMap_RKC_Database();
        


        public float ChodProcent(DateTime start, DateTime end, int stroj) //zjištění chodu zařízení v časovém rozmezí
        {
            return 0;
        }

        public float ChodProcent(DateTime start, DateTime end, int oddeleni, int skupina) // zjištění chodu zařízení pro oddělení
        {
            return 0;
        }

        public float ChodProcent(DateTime start, DateTime end, int[] stroje) //zjištěné chodu zadaných zařízení v poli v časovém rozmezí
        {
            return 0;
        }

        public int ChodTaktu(DateTime start, DateTime end) //zjištění taktů pro celou výrobu podle zadaných časových údajů
        {
            return 0;
        }

        public int ChodTaktu(DateTime start, DateTime end, int stroj) //zjištění taktů zařízení v časovém rozmezí
        {
            return 0;
        }

        public int ChodTaktu(DateTime start, DateTime end, int oddeleni, int skupina) // zjištění taktů zařízení pro zadané oddělení
        {
            return 0;
        }

        public int ChodTaktu(DateTime start, DateTime end, int[] stroje) //zjištěné chodu zadaných zařízení v poli v časovém rozmezí
        {
            return 0;
        }

    }
}
