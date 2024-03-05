using System.ComponentModel;

namespace Core.Enums
{
    public enum Gender
    {
        [Description("Masculino")]
        Masculine = 1,
        [Description("Feminino")]
        Feminine = 2,
        [Description("Não definido")]
        Undefined = 3
    }
}
