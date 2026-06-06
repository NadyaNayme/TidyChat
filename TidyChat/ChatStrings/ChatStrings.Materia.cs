using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/1200?pretty=true">You successfully extract materia from …</see>
    public static readonly LocalizedStrings MateriaExtract = new()
    {
        Jpn = ["マテリア精製"],
        Eng = ["successfully", "extract"],
        Deu = ["extrahiert"],
        Fra = ["matérialisez"]
    };

    /// <see href="https://xivapi.com/LogMessage/1201?pretty=true">You successfully attach materia to …</see>
    public static readonly LocalizedStrings MateriaAttach = new()
    {
        Jpn = ["装着"],
        Eng = ["successfully", "attach"],
        Deu = ["eingesetzt"],
        Fra = ["serti"]
    };

    /// <see href="https://xivapi.com/LogMessage/1202?pretty=true">You are unable to attach materia to …</see>
    public static readonly LocalizedStrings MateriaOvermeldFailure = new()
    {
        Jpn = ["装着", "失敗"],
        Eng = ["unable", "attach"],
        Deu = ["fehlgeschlagen"],
        Fra = ["échoué"]
    };

    /// <see href="https://xivapi.com/LogMessage/1953?pretty=true">You attempt to remove the materia from …</see>
    public static readonly LocalizedStrings MateriaAttemptRemove = new()
    {
        Jpn = ["マテリア", "取り外し"],
        Eng = ["remove", "materia"],
        Deu = ["materia", "entfernt"],
        Fra = ["desserti", "matéria"]
    };

    /// <see href="https://xivapi.com/LogMessage/1954?pretty=true">You receive … (materia retrieval).</see>
    public static readonly LocalizedStrings MateriaRetrieved = new()
    {
        Jpn = ["回収", "成功"],
        Eng = ["you", "receive"],
        Deu = ["zurückgewonnen"],
        Fra = ["récupérez"]
    };

    /// <see href="https://xivapi.com/LogMessage/1955?pretty=true">… shatters …</see>
    public static readonly LocalizedStrings MateriaShatters = new()
    {
        Jpn = ["粉々"],
        Eng = ["shatters"],
        Deu = ["zerfällt"],
        Fra = ["désintégré"]
    };
}