using System.ComponentModel.DataAnnotations;

namespace WebsiteParsing.Domain.Entities
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }
        public string ModelName { get; set; }
        public int ModelCode {  get; set; }
        public string? DateRange {  get; set; }
        public ICollection<Equipment>? Equipment {  get; set; }
    }
}
