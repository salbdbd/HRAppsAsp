using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Model.Token;
public class TokenResponseDto
{
    public string? Token { get; set; }
    //public string? Expiration { get; set; }
    //public string? RefreshToken { get; set; }
   // public DateTime? RefreshTokenExpiration { get; set; }
    public string? LoginID { get; set; }
    public string? UserName { get; set; }
    public string? EmpName { get; set; }
    public string? LoginPassword { get; set; }
    public int? UserTypeId { get; set; }
    // public string? UserTypeName { get; set; }
    public string? EmpCode { get; set; }
    public string? IsActive { get; set; }
  //  public int? ClientId { get; set; }
  //  public int?  IsHaveSms { get; set; }
  //  public string? ClientName { get; set; }
    public int? CompanyID { get; set; }
    public string? CompanyName { get; set; }
    public int? Gender { get; set; }
    public int? GradeValue { get; set; }
    public string? Department { get; set; }
    public string? ReportTo { get; set; }
    public string? RecommendTo { get; set; }
  //  public int? BranchId { get; set; }
   // public string? BranchName { get; set; }
  //  public DateTime? CreatedDate { get; set; }
  //  public int? CreatedBy { get; set; }
 //   public string?   CreatorName { get; set; }
  //  public DateTime? ModifiedDate { get; set; }
  //  public int ? ModifiedBy { get; set; }
 //   public string? ModifierName { get; set; }
}


