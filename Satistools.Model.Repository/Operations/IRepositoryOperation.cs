namespace Satistools.Model.Repository.Operations
{

    /// <summary>
    /// Represents an postponed operation which whould be applied when the repository is saving its changes.
    /// </summary>
    public interface IRepositoryOperation
    {
        /// <summary>
        /// Apply the changes made by this operation.
        /// </summary>
        void Apply();
    }
}