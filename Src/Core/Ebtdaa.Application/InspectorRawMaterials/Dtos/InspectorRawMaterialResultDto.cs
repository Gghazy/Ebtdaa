namespace Ebtdaa.Application.InspectorRawMaterials.Dtos
{
    public class InspectorRawMaterialResultDto
    {
        public int Id { get; set; }
        public int RawMaterialId { get; set; }
        public string RawMaterialName { get; set; }
        public bool IsImageClear { get; set; }
        public bool IsPaperClear { get; set; }
        public string Comment { get; set; }
        public int PhotoId { get; set; }
        public int PaperId { get; set; }
        public int? CorrectPhotoId { get; set; }
        public int? CorrectPaperId { get; set; }
        public int PeriodId { get; set; }
        public int FactoryId { get; set; }
    }
}
