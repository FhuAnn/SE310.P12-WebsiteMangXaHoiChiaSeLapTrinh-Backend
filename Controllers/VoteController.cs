using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Add;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Get;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : Controller
    {
        private readonly Stackoverflow1511Context context;
        private readonly IMapper mapper;
        private readonly IVoteRepository voteRepository;

        public VoteController(Stackoverflow1511Context context,IMapper mapper, IVoteRepository voteRepository) {
            this.context = context;
            this.mapper = mapper;
            this.voteRepository = voteRepository;
        }

        [HttpGet("votedetail")]
        public async Task<IActionResult> VoteDetail(Guid postId)
        {
            var voteDetails = await voteRepository.GetVoteDetails(postId);
            if (voteDetails == null)
            {
                return NotFound();  // Nếu không tìm thấy bài đăng, trả về 404.
            }
            return Ok(voteDetails);
        }

        [HttpPost("vote")]
        public async Task<IActionResult> VotePost([FromBody] AddVote addVote)
        {
            var voteDomain = mapper.Map<Vote>(addVote);
            voteDomain = await voteRepository.VotePost(voteDomain);
            return Ok(mapper.Map<VoteDto>(voteDomain));
        }

    }
}
