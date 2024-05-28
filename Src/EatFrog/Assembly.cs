namespace EatFrog;

public abstract class Assembly<TMaschine>
    where TMaschine : new()
{
    public static TMaschine maschine = new();

    public abstract Assembly<TMaschine> Load(Stream strm);
    public abstract void Save(Stream strm);
}