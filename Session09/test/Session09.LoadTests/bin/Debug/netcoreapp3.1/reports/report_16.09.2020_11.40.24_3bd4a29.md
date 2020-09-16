# Scenario: `GET resources`

- Duration: `00:00:10`
- RPS: `1155`
- Concurrent Copies: `1`

| __step__                 | __details__                                                             |
|--------------------------|-------------------------------------------------------------------------|
| name                     | `init`                                                                  |
| request count            | all = `11557`, OK = `11557`, failed = `0`                               |
| response time            | RPS = `1155`, min = `0`, mean = `0`, max = `1062`                       |
| response time percentile | 50% = `1`, 75% = `1`, 95% = `1`, StdDev = `22`                          |
| data transfer            | min = `0.080 Kb`, mean = `0.080 Kb`, max = `0.080 Kb`, all = `0.900 MB` |