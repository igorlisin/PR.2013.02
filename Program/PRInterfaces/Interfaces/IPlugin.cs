namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Дополнение
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Метод. Запрашивает у дополнения список поддерживаемых интерфейсов
        /// </summary>
        void Interfaces();

        /// <summary>
        /// Метод. Передает дополнению объект для взаимодействия
        /// </summary>
        void SetData();

        /// <summary>
        /// Метод. Запускает выполнение дополнения
        /// </summary>
        void Run();
    }
}
