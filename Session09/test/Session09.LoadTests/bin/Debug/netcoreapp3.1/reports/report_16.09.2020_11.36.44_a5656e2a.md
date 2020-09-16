# Scenario: `GET resources`

- Duration: `00:00:10`
- RPS: `1183`
- Concurrent Copies: `1`

| __step__                 | __details__                                                             |
|--------------------------|-------------------------------------------------------------------------|
| name                     | `init`                                                                  |
| request count            | all = `11836`, OK = `11836`, failed = `0`                               |
| response time            | RPS = `1183`, min = `0`, mean = `0`, max = `86`                         |
| response time percentile | 50% = `1`, 75% = `1`, 95% = `1`, StdDev = `2`                           |
| data transfer            | min = `0.080 Kb`, mean = `0.080 Kb`, max = `0.080 Kb`, all = `0.930 MB` |