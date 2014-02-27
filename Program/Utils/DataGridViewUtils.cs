using System.Windows.Forms;

namespace Utils
{
    public class DataGridViewUtils
    {
        /// <summary>
        /// Статический метод. Задает ширину последнего столбца компонента "DataGridView"
        /// </summary>
        public static void SetLastColumnWidth(DataGridView dataGridView)
        {
            int counter;                                                                                            // Счетчик циклов
            int rowCount;                                                                                           // Количество столбцов
            int rowsWidth;                                                                                          // Общая ширина столбцов (исключая последний столбец)
            int lastColumnWidth;                                                                                    // Ширина последнего столбца

            rowCount = dataGridView.Columns.Count;                                                                  // Получить количество столбцов

            if (rowCount > 0)                                                                                       // Проверить количество столбцов
            {
                rowsWidth = 0;                                                                                      // Задать общую ширину столбцов                                            

                for (counter = 0; counter < rowCount - 1; counter++)                                                // Выполнить для всех столбцов
                {
                    rowsWidth += dataGridView.Columns[counter].Width;                                               // Вычислить общую ширину столбцов  
                }

                lastColumnWidth = dataGridView.ClientSize.Width - dataGridView.RowHeadersWidth - rowsWidth - 12;    // Вычислить ширину последнего столбца
                dataGridView.Columns[rowCount - 1].Width = lastColumnWidth;                                         // Задать ширину последнего столбца
            }
        }

        /// <summary>
        /// Статический метод. Выделяет строку в компоненте "DataGridView"
        /// </summary>
        public static void SelectRow(DataGridView dataGridView, int rowIndex)
        {
            dataGridView.Rows[rowIndex].Selected = true;                            // Выделить заданную строку
            dataGridView.CurrentCell = dataGridView.SelectedRows[0].Cells[0];       // Выделить заданную ячейку (необходимо для установки позиции "стрелки" в столбце заголовке)
        }
    }
}
