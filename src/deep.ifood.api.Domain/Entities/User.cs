namespace deep.ifood.api.Domain.Entities
{
    public class User : BaseEntity
    {
        public int IdEmpresa { get; set; }
        public string Guid { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public virtual Company Empresa { get; set; }
    }
}
