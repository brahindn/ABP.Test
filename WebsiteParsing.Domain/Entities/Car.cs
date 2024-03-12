using Abp.Timing;
using System.ComponentModel.DataAnnotations;

namespace WebsiteParsing.Domain.Entities
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }
        public string ModelName { get; set; }
        public int ModelCode {  get; set; }
        public DateTime DateRange {  get; set; }
        public ICollection<Equipment> Equipment {  get; set; }
    }
}
