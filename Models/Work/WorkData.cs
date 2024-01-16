namespace MauiExample.Models.Work
{
    public class WorkData
    {
        public int Id { get; set; }

        public string InternalWorkCode { get; set; }

        public string GDERecordNumber { get; set; }

        public bool WasGDERecordNumberValidated { get; set; }

        public int? ProjectId { get; set; }

        public int? PlanId { get; set; }

        public DateTime? ExpectedEndDate { get; set; }

        public DateTime? InitialActDate { get; set; }

        public DateTime? ProvitionalReceptionDate { get; set; }

        public DateTime? BidDate { get; set; }

        public DateTime? ContractSignDate { get; set; }

        public DateTime LastActivityDate { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string WorkAccessibilityInformation { get; set; }

        public Guid? TechnicalManagerUserId { get; set; }

        public Guid? OrganismInChargeId { get; set; }

        public Guid? OwnerOrganismId { get; set; }

        public int Step { get; set; }

        public int State { get; set; }

        public int? WorkflowType { get; set; }

        public string TechnicalCharacteristics { get; set; }

        public string WorkImpactInCoveragePercentage { get; set; }

        public decimal? UpdatedAmount { get; set; }

        public int? BidNumberPrefix { get; set; }

        public string BidNumber { get; set; }

        public bool HasWorkSign { get; set; }

        public bool UpdatedWorkSign { get; set; }

        public bool CanBeVisited { get; set; }

        public Guid CreatorUserId { get; set; }

        public string CreatorUserFullName { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Archived { get; set; }

        public int? ArchiveReason { get; set; }

        public int? ArchiveSubReason { get; set; }

        public decimal PhysicalCompleteness { get; set; }

        public decimal FinancialCompleteness { get; set; }

        public int? UnitOfMeasure { get; set; }

        public int? Area { get; set; }

        public decimal NotCertifiedAmount { get; set; }

        public decimal AmountInProcess { get; set; }

        public decimal AmountReadyForPayment { get; set; }

        public decimal AmountAccrued { get; set; }

        public decimal AmountPaid { get; set; }

        public decimal? TotalCost { get; set; }

        public int? WorkTypeId { get; set; }

        public int? WorkTypeSubGroupId { get; set; }

        public int? WorkTypeGroupId { get; set; }

        public int? CaptudataId { get; set; }
    }
}
