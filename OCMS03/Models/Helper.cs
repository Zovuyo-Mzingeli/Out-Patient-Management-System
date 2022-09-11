using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;

namespace OCMS03.Models
{
    public class Helper
    {
        OCMS03_TheCollectiveContext dbContext = new OCMS03_TheCollectiveContext();

        public int January()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-01-01' AND '2021-01-31'");

            var data = dbContext.Jan.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int February()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-02-01' AND '2021-02-28'");

            var data = dbContext.Feb.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }
            return f;
        }

        public int March()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-03-01' AND '2021-03-31'");

            var data = dbContext.Mar.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int April()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-04-01' AND '2021-04-30'");

            var data = dbContext.Apr.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int May()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-05-01' AND '2021-05-31'");

            var data = dbContext.May.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int June()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-06-01' AND '2021-06-30'");

            var data = dbContext.Jun.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int July()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-07-01' AND '2021-07-31'");

            var data = dbContext.Jul.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int August()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-08-01' AND '2021-08-30'");

            var data = dbContext.Aug.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int September()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-09-01' AND '2021-09-30'");

            var data = dbContext.Sep.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int October()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-10-01' AND '2021-10-31'");

            var data = dbContext.Oct.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int November()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-11-01' AND '2021-11-30'");

            var data = dbContext.Nov.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int December()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-12-01' AND '2021-12-31'");

            var data = dbContext.Dec.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int[] Data()
        {
            int[] objs = { January(), February(), March(), April(), May(), June(), July(), August(), September(), October(), November(), December() };

            return objs;
        }
        public int JanAppr()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-01-01' AND '2021-01-31'  AND apptStatus = 'Approved'");

            var data = dbContext.JR.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int FebAppr()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-02-01' AND '2021-02-28'  AND apptStatus = 'Approved'");

            var data = dbContext.FR.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int MarAppr()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-03-01' AND '2021-03-31'  AND apptStatus = 'Approved'");

            var data = dbContext.MR.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int AprAppr()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-04-01' AND '2021-04-30'  AND apptStatus = 'Approved'");

            var data = dbContext.AR.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int MayAppr()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-05-01' AND '2021-05-31'  AND apptStatus = 'Approved'");

            var data = dbContext.MA.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int JunAppr()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-06-01' AND '2021-06-30'  AND apptStatus = 'Approved'");

            var data = dbContext.JU.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int JulAppr()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-07-01' AND '2021-07-31'  AND apptStatus = 'Approved'");

            var data = dbContext.JL.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int AugAppr()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-08-01' AND '2021-08-31'  AND apptStatus = 'Approved'");

            var data = dbContext.AU.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int SepAppr()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-09-01' AND '2021-09-30'  AND apptStatus = 'Approved'");

            var data = dbContext.SE.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int OctAppr()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-10-01' AND '2021-10-31'  AND apptStatus = 'Approved'");

            var data = dbContext.OC.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int NovAppr()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-11-01' AND '2021-11-30'  AND apptStatus = 'Approved'");

            var data = dbContext.NO.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int DecAppr()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-12-01' AND '2021-12-31'  AND apptStatus = 'Approved'");

            var data = dbContext.DE.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }

        public int[] Datas()
        {
            int[] objs = { JanAppr(), FebAppr(), MarAppr(), AprAppr(), MayAppr(), JunAppr(), JulAppr(), AugAppr(), SepAppr(), OctAppr(), NovAppr(), DecAppr() };

            return objs;
        }

        public int JanC()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-01-01' AND '2021-01-31'  AND apptStatus = 'Cancelled'");

            var data = dbContext.JR.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int FebC()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-02-01' AND '2021-02-28'  AND apptStatus = 'Cancelled'");

            var data = dbContext.FR.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int MarC()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-03-01' AND '2021-03-31'  AND apptStatus = 'Cancelled'");

            var data = dbContext.MR.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int AprC()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-04-01' AND '2021-04-30'  AND apptStatus = 'Cancelled'");

            var data = dbContext.AR.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int MayC()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-05-01' AND '2021-05-31'  AND apptStatus = 'Cancelled'");

            var data = dbContext.MA.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int JunC()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-06-01' AND '2021-06-30'  AND apptStatus = 'Cancelled'");

            var data = dbContext.JU.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int JulC()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-07-01' AND '2021-07-31'  AND apptStatus = 'Cancelled'");

            var data = dbContext.JL.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int AugC()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-08-01' AND '2021-08-31'  AND apptStatus = 'Cancelled'");

            var data = dbContext.AU.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int SepC()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-09-01' AND '2021-09-30'  AND apptStatus = 'Cancelled'");

            var data = dbContext.SE.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int OctC()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-10-01' AND '2021-10-31'  AND apptStatus = 'Cancelled'");

            var data = dbContext.OC.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int NovC()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-11-01' AND '2021-11-30'  AND apptStatus = 'Cancelled'");

            var data = dbContext.NO.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }
        public int DecC()
        {
            dbContext.Database.ExecuteSqlRaw($"SELECT COUNT(*)AS Total FROM tblAppointment WHERE AppointmentDate BETWEEN '2021-12-01' AND '2021-12-31'  AND apptStatus = 'Cancelled'");

            var data = dbContext.DE.ToList();
            int f = 0;
            foreach (var d in data)
            {
                f = d.Total;
            }

            return f;
        }

        public int[] Dat()
        {
            int[] objs = { JanC(), FebC(), MarC(), AprC(), MayC(), JunC(), JulC(), AugC(), SepC(), OctC(), NovC(), DecC() };

            return objs;
        }
    }
}
