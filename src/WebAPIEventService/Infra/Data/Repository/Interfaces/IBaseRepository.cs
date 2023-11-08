using WebAPIEventService.Domain.Entities;

namespace WebAPIEventService.Infra.Data.Repository.Interfaces
{
    public interface IBaseRepository
    {
        /// <summary>
        /// Retorna uma entidade pelo Id
        /// </summary>
        Task<T?> GetByIdAsync<T>(int id) where T : BaseEntity;

        /// <summary>
        /// Retorna todas as entidades da tabela
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync<T>() where T : BaseEntity;

        /// <summary>
        /// Adiciona uma entidade ao contexto.
        /// </summary>
        void Add<T>(T entity) where T : BaseEntity;

        /// <summary>
        /// Atualiza uma entidade no contexto.
        /// </summary>
        void Update<T>(T entity) where T : BaseEntity;

        /// <summary>
        /// Remove uma entidade do contexto.
        /// </summary>
        void Delete<T>(T entity) where T : BaseEntity;
    }
}
