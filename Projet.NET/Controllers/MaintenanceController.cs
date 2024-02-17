using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Projet.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        [HttpGet("FullMaintenance")]
        public MaintenanceModel? GetFullRecipe(int recipeId)
        {
            return RecipeFactory.ConvertToApiModel(_dataContext.Set<Recipe>()
                .Include(x => x.Parameters)
                .FirstOrDefault(x => x.Id == recipeId));
        }
    }
}
