/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

namespace DemoApplication.IdentityModel.Tokens.Http
{
    public enum ClientCertificateMode
    {
        ChainValidation,
        PeerValidation,
        ChainValidationWithIssuerSubjectName,
        ChainValidationWithIssuerThumbprint,
        IssuerThumbprint
    }
}
