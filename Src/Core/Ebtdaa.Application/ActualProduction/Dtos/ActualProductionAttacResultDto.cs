using Ebtdaa.Common.Enums;


namespace Ebtdaa.Application.ActualProduction.Dtos
{
    public class ActualProductionAttacResultDto
    {
        public int Id { get; set; }
        public int AttachmentId { get; set; }
        public int FactoryId { get; set; }
        public ActualProductionFileType Type { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
