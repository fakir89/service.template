﻿using MassTransit;
using Service.Template.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Template.Consumers
{
    /// <summary>
    /// Обработчик сообщения получения списка Placeholder.
    /// </summary>
    public class GetAllPlaceholdersConsumer : IConsumer<GetAllPlaceholdersCommand>
    {
        private readonly IPlaceholderService service;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="GetAllPlaceholdersConsumer"/>.
        /// </summary>
        /// <param name="service">Сервисный объект для управления Placeholder.</param>
        public GetAllPlaceholdersConsumer(IPlaceholderService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Обработать сообщение.
        /// </summary>
        /// <param name="context">Контекст обработки сообщения.</param>
        /// <returns>Асинхронная операция <see cref="Task"/>.</returns>
        public async Task Consume(ConsumeContext<GetAllPlaceholdersCommand> context)
        {
            List<Placeholder> placeholders = this.service.Get();

            await context.RespondAsync(new GetAllPlaceholdersResponse { Placeholders = placeholders });
        }
    }
}