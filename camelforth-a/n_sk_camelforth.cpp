/* Sun  2 Jul 16:18:33 UTC 2023 */
#include <Arduino.h>

#ifdef __cplusplus
extern "C" {
#endif

void this_here();
void interpreter(void);

extern void this_here_now();

char getch(void) {
//  this_here_now();
    bool waiting_ch = 0;

    for (int testing = 5; testing > 0; testing--) {
      ;
    }

    while (!waiting_ch) {
      waiting_ch = Serial1.available();
      // this_here_now(); // loop
    }

    if (waiting_ch) {
      char ch = Serial1.read();
      return ch;
    }
}

void putch(char c) {
    Serial1.write(c);
    // printf("%c", c);

    return ;  // doesn't have to do anything
}


int getquery(void) {
    // return(UARTCharsAvail(UART0_BASE) != 0);
    return(0 != 0);
}

#ifdef __cplusplus
}
#endif

void trapped() {
  this_here_now();
  this_here_now();

  interpreter();

  while(-1);
}

#define THIS_LED_BDEF 31

void setup() {
  Serial1.begin(115200);
  Serial1.write(' ');
  Serial1.println("\n\n Camelforth in C\n\n");
  Serial1.println("2023 Jul 3rd 14:19:21 UTC\n\n");
  Serial1.println(" - for black pill 411CE on Serial1 A9 A10\n\n");
  pinMode(THIS_LED_BDEF, OUTPUT);

  for (int count = 3; count > 0; count--) {
    digitalWrite(THIS_LED_BDEF, 0);
    delay(90);
    digitalWrite(THIS_LED_BDEF, 1);
    delay(700);
  }
  trapped();
}

void loop() {
  ;
}

// END.
