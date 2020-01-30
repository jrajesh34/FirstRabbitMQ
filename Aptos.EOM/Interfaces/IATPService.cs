using Aptos.EOM.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aptos.EOM.Interfaces
{
    interface IATPService
    {
        EDDResponseDto RequestATPService(EDDRequestDto requestDto);
    }
}
