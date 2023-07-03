#!/bin/sh
  arduino-cli compile --fqbn STMicroelectronics:stm32:GenF4:pnum=BLACKPILL_F411CE,rtlib=nano ${1}
exit 0

