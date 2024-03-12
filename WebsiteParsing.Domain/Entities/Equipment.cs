using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteParsing.Domain.Entities
{
    public class Equipment
    {
        [Key]
        public Guid Id {  get; set; }
        public string EquipmentName { get; set; }
        public string Engine { get; set; }
        public string Body {  get; set; }
        public string Grade {  get; set; }
        public string Transmission { get; set; }
        public string GearShiftType { get; set; }
        public string Cab {  get; set; }
        public string TransmissionModel {  get; set; }
        public string LoadingCapacity {  get; set; }

        public Guid CarId { get; set; }
        [ForeignKey("CarId")]
        public Car Car { get; set; }


    }
}
