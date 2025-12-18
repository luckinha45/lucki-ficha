using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api")]
public class CtrSheet
{
    [HttpGet("fichas")]
    public string GetFichas()
    {
        string jsonContent = "";
        using (var fs = new StreamReader("./db/sheets.json"))
        {
            jsonContent = fs.ReadToEnd();
        }

        return jsonContent;
    }
}