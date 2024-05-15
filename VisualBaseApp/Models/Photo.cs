using System;
namespace VisualBaseApp.Models
{
	public class Photo
	{
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? FilePath { get; set; }
        public required ICollection<ImageData> ImageData { get; set; }
        public DateTime UploadDate { get; set; }
    }
    public class ImageData
    {
        public int Id { get; set; }
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }
        public byte[] ImageBytes { get; set; }
    }


}

