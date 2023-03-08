using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorAppMasterCrud
{
    public class AppointmentService
    {
        ApDBContext db;
        public AppointmentService(ApDBContext _db)
        {
            db = _db;
        }

        public string AddAppointmentServiceVm(AppointmentServiceVm md)
        {
            Appointment m = new Appointment() { Appointment_ID = md.Appointment.Appointment_ID, Appointment_Name = md.Appointment.Appointment_Name, Date = md.Appointment.Date, Phone = md.Appointment.Phone };
            db.Appointment.Add(m);
            db.SaveChanges();
            db.Entry(m).State = EntityState.Detached;
            foreach (var c in md.Service)
            {
                Service d = new Service()
                {
                    Service_ID = c.Service_ID,
                    Service_Name = c.Service_Name,
                    Appointment_ID = c.Appointment_ID,
                    Service_Fee = c.Service_Fee,
                    Picture = c.Picture,
                    //date = DateTime.Parse(c.date.ToShortDateString()),

                };
                db.Service.Add(d);
            }
            db.SaveChanges();

            return "1";
        }
        public string RemoveAppointmentServiceVm(string id)
        {
            List<Service> st5 = db.Service.Where(xx => xx.Appointment_ID == id).ToList();
            db.Service.RemoveRange(st5);
            db.SaveChanges();
            Appointment st6 = db.Appointment.Find(id);
            if (st6 != null)
            {
                db.Appointment.Remove(st6);
            }
            db.SaveChanges();

            return "1";
        }
        public string UpdateAppointmentServiceVm(AppointmentServiceVm md)
        {
            RemoveAppointmentServiceVm(md.Appointment.Appointment_ID);
            AddAppointmentServiceVm(md);
            return "1";
        }
        public List<Appointment> GetTwoTables()
        {
            List<Appointment> md = new List<Appointment>();

            md = (from d in db.Appointment select d).ToList();
            //var jo = JsonSerializer.Deserialize<Master>(a);
            return md;
        }
        public AppointmentServiceVm GetTwoTables2(string id)
        {
            AppointmentServiceVm md = new AppointmentServiceVm();
            Appointment a = new Appointment();
            a = (from d in db.Appointment where d.Appointment_ID == id select d).FirstOrDefault();
            md.Appointment = a;
            List<Service> b = new List<Service>();
            b = (from d in db.Service where d.Appointment_ID == id select d).ToList();
            md.Service = b;
            if (a != null) db.Entry(a).State = EntityState.Detached;
            return md;

        }

        public string GenerateCode()
        {
            string a1 = "";
            string b1 = "";

            try
            {
                var a = (from det in db.Appointment select det.Appointment_ID.Substring(3)).Max();
                if (a == null)
                    a = "0";
                int b = int.Parse(a.ToString()) + 1;
                if (b < 10)
                {
                    b1 = "000" + b.ToString();
                }
                else if (b < 100)
                {
                    b1 = "00" + b.ToString();
                }
                else if (b < 1000)
                {
                    b1 = "0" + b.ToString();
                }
                else
                {
                    b1 = b.ToString();
                }
                a1 = "AC-" + b1.ToString();
            }
            catch (Exception ex)
            {
                a1 = "AC-0001";
            }
            return a1;
        }
        public int Child_Exists(string id)
        {
            var a = (from p in db.Service where p.Service_ID == id select new { p.Service_ID, }).FirstOrDefault();
            if (a != null)
                return 1;
            else
                return 0;
        }


    }
}
