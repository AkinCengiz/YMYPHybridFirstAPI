using System;
using System.Collections.Generic;

namespace YMYPHybridFirst.Models;

public partial class UserOperationClaim
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? OperationClaimId { get; set; }
}
