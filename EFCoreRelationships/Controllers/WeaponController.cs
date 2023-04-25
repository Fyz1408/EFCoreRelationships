using Microsoft.AspNetCore.Mvc;

namespace EFCoreRelationships.Controllers
{
    public class WeaponController : Controller
    {
        private readonly DataContext _context;
        public WeaponController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("AddWeapon")]
        public async Task<ActionResult<Character>> AddWeapon(AddWeaponDto request)
        {
            var character = await _context.Characters.FindAsync(request.CharacterId);
            if (character == null)
                return NotFound();
           
            var newWeapon = new Weapon
            {
                Name = request.Name,
                Damage = request.Damage,
                Character = character,
            };

            _context.Weapons.Add(newWeapon);
            await _context.SaveChangesAsync();

            return character;
        }
    }
}
