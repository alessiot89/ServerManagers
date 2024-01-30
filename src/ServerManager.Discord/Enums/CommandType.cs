namespace ServerManagerTool.DiscordBot.Enums
{
    public enum CommandType
    {
        Info,
        List,
        Status,

        Backup,
        Restart,
        Shutdown,
        Start,
        Stop,
        Update,

        ///<summary>To add an Exclusive Join ID</summary>
        AddId,
        ///<summary>To remove an Exclusive Join ID</summary>
        RemoveId,
        ///<summary>To check an Exclusive Join ID if present</summary>
        CheckId,
    }
}
