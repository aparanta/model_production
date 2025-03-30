namespace CoreApplication
{
    public enum EquipmentState
    {
        Red,
        Yellow,
        Green
    }
    public enum EquipmentType
    {
        Type1,
        Type2,
        Type3
    }
    

    public class Equipment
    {
        public DateTime LastUpdated { get; set; }

        public Guid ID { get; set; }

        public EquipmentState? State { get; set; }
    }
}
