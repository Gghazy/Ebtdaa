namespace Ebtdaa.Application.InspectorRawMaterials.Dtos
{
    public class InspectorRawMaterialRequestDto
    {
        public int Id { get; set; }
        public int RawMaterialId { get; set; }
        public bool IsClearImage { get; set; }
        public string Comment { get; set; }
        public int? PhotoId { get; set; }
        public int? PaperId { get; set; }
    }
}
