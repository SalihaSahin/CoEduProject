using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class TrainerOperationClaim:IEntity
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
