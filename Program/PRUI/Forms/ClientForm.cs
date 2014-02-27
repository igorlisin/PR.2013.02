﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Utils;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

using PRUI.TemplateForms;

namespace PRUI.Forms
{
    /// <summary>
    /// Форма. Форма редактирования клиента
    /// </summary>
    public partial class ClientForm : TemplateEntityPersonForm
    {
        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public ClientForm(IClient client, IMans mans)
        {
            InitializeComponent();                  // Инициализировать компоненты формы

            _client = client;                       // Сохранить клиента в поле
            _mans = mans;                           // Сохранить список людей в поле

            _manAfterRelinking = client.Man;        // Сохранить человека, связанного с клиентом

            CleanAllData();                         // Очистить компоненты всех групп

            CopyDataFromEntity();                   // Скопировать данные клиента в компоненты формы
        }

        #endregion

        #region Methods

        #region Copy

        /// <summary>
        /// Метод. Копирует данные из сущности в компоненты формы
        /// </summary>
        protected override void CopyDataFromEntity()
        {
            CopyIdFromEntity((IEntity)_client);                 // Скопировать идентификатор
            CopyDescriptionFromEntity((IEntity)_client);        // Скопировать описание

            CopyLinkedDataFromEntity();                         // Скопировать данные из сущностей, связанных с основной сущностью 
            CopyClientFromEntity();                             // Скопировать данные клиента
        }

        /// <summary>
        /// Метод. Копирует данные из сущностей, связанных с основной сущностью
        /// </summary>
        protected override void CopyLinkedDataFromEntity()
        {
            if (_manAfterRelinking != null)                                     // Проверить человека, связанного с клиентом
            {
                if (_manAfterRelinking.Document != null)                        // Проверить документ, связанный с человеком
                {
                    CopyDocumentFromEntity(_manAfterRelinking.Document);        // Скопировать данные документа      
                }
                CopyManFromEntity(_manAfterRelinking);                          // Скопировать данные человека    
            }
        }

        /// <summary>
        /// Метод. Копирует данные сущности в компоненты клиента
        /// </summary>
        private void CopyClientFromEntity()
        {
        }

        /// <summary>
        /// Метод. Копирует данные из компонентов формы в данные сущности
        /// </summary>
        protected override void CopyDataToEntity()
        {
            ((IEntity)_client).Description = Description;       // Скопировать описание

            _client.Man = _manAfterRelinking;                   // Скопировать человека после перепривязки
        }

        #endregion

        #endregion
    }
}