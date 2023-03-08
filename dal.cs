using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorAppMasterCrud
{
    public class Appointment
    {
        [Key]
        public string Appointment_ID { get; set; }
        public string Appointment_Name { get; set; }
        public DateTime? Date { get; set; }
        public string Phone { get; set; }
        public IList<Service>? Service { get; set; }


    }
    public class Service
    {
        [Key]
        public string Service_ID { get; set; }
        public string Service_Name { get; set; }
        [ForeignKey("Appointment")]
        public string Appointment_ID { get; set; }
        public string Service_Fee { get; set; }
        public string Picture { get; set; }
        public Appointment Appointment { get; set; }


    }
    public class AppointmentServiceVm
    {
        public AppointmentServiceVm()
        {
            this.Appointment = new Appointment();
            this.Service = new List<Service>();

        }
        public Appointment Appointment { get; set; }
        public List<Service> Service { get; set; }
        
    }

}
