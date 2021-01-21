namespace MySolution.Web.Api.DataTransferObjects.Responses
{
    public sealed class ProductResponse
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        #endregion
    }
}