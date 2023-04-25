using Microsoft.AspNetCore.Mvc;

namespace EFCoreRelationships.Controllers
{
    public class SkillController : Controller
    {
        private readonly DataContext _context;
        public SkillController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllSkills")]
        public async Task<ActionResult<List<Skill>>> GetSkills()
        {
            var skills = await _context.Skills.ToListAsync();

            return skills;
        }

        [HttpPost("AddSkill")]
        public async Task<ActionResult<Skill>> AddSkill(AddSkillDto request)
        {
            var newSkill = new Skill
            {
                Name = request.Name,
                Damage = request.Damage,
            };

            _context.Skills.Add(newSkill);
            await _context.SaveChangesAsync();

            return newSkill;
        }
    }
}
