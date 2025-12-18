namespace backend.Models;

class MdlSheet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? ImgUrl { get; set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    public MdlSheet(int id, string name, string? imgUrl)
    {
        Id = id;
        Name = name;
        ImgUrl = imgUrl;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}
