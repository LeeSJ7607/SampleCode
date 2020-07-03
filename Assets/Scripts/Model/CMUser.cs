public sealed class CMUser : Model
{
    public int Id { get; }
    public string Name { get; }

    public iLevelData LevelData { get; private set; }
    public iTicketData TicketData { get; private set; }

    public CMUser(/*int id_, string name_*/)
    {
        // Id = id_;
        // Name = name_;
        
        ResourceManager.Instance.GetResource<TableUserLevel>((table_) => LevelData = new CMLevel(1, table_));
        ResourceManager.Instance.GetResource<TableTicket>((table_) => TicketData = new CMTicket(1, 0, 0, table_));
    }
}