using System.Collections.Generic;

namespace STAPI.DTOs
{
    public class RankingDto
    {
        public List<UserRankingDto> Rankings { get; set; }
    }

    public class UserRankingDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public decimal TotalValue { get; set; }
    }
}