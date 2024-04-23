using Ekzakt.Utilities.Helpers;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Vmk.Application.Models;
using Vmk.Client.Extensions;
using Vmk.Infrastructure.Configuration;
using Vmk.Infrastructure.Queueing;

namespace Vmk.Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly VmkOptions _options;
        private readonly IValidator<ContactModel> _validator;
        private readonly IQueueService _queueService;


        public IndexModel(
            ILogger<IndexModel> logger,
            IOptions<VmkOptions> options,
            IValidator<ContactModel> validator,
            IQueueService queueService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _options = options.Value ?? throw new ArgumentNullException(nameof(options));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _queueService = queueService ?? throw new ArgumentException(nameof(queueService));
        }


        public async Task<IActionResult> OnPostSubmitChatAsync(ContactModel contactModel)
        {
            ValidationResult result = await _validator.ValidateAsync(contactModel);

            if (!result.IsValid)
            {
                return new BadRequestResult();
            }

            try
            {
                var message = new ContactFormQueueMessage<ContactModel>(contactModel)
                {
                    CultureName = Thread.CurrentThread.CurrentCulture.Name.ToLower(),
                    IpAddress = HttpContext.GetIpAddress(),
                    UserAgent = HttpContext.GetUserAgent()
                };

                if (await _queueService.SendMessageAsync(_options?.QueueNames?.ContactForm ?? string.Empty, message))
                {
                    return new OkResult();
                }

                return new BadRequestResult();
            }
            catch (Exception ex) 
            {
                _logger.LogError("Error submitting contact form. Exception: {Exception}", ex);

                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
