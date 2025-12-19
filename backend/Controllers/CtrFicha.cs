using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("api")]
public class CtrFicha
{
    [HttpGet("fichas")]
    public string GetFichas()
    {
        return "";
    }
}