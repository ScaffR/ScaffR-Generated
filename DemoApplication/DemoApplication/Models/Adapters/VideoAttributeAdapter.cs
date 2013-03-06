using System.Collections.Generic;
using System.Web.Mvc;
using DemoApplication.Models.Attributes;
using DemoApplication.Models.Rules;

namespace DemoApplication.Models.Adapters
{
    public class VideoAttributeAdapter : DataAnnotationsModelValidator<VideoAttribute>
    {
        public VideoAttributeAdapter(ModelMetadata metadata, ControllerContext context, VideoAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationVideoRule(ErrorMessage) };
        }
    }
}