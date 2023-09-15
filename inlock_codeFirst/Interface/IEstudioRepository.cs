using inlock_codeFirst.Domains;

namespace inlock_codeFirst.Interface
{
    public interface IEstudioRepository
    {
        List<EstudioDomain> Listar();

        EstudioDomain BuscarPoId(Guid id);

        void Cadastrar(EstudioDomain estudio);

        void Atualizar(Guid id, EstudioDomain estudio);

        void Deletar(Guid id);

        List<EstudioDomain> ListarComJogos();
    }
}
