## 18.2.0 (June 14, 2022)

### React DOM

* Provide a component stack as a second argument to `onRecoverableError`. ([@gnoff](https://github.com/gnoff) in [#24591](https://github.com/facebook/react/pull/24591))
* Fix hydrating into `document` causing a blank page on mismatch. ([@gnoff](https://github.com/gnoff) in [#24523](https://github.com/facebook/react/pull/24523))
* Fix false positive hydration errors with Suspense. ([@gnoff](https://github.com/gnoff) in [#24480](https://github.com/facebook/react/pull/24480) and  [@acdlite](https://github.com/acdlite) in [#24532](https://github.com/facebook/react/pull/24532))
* Fix ignored `setState` in Safari when adding an iframe. ([@gaearon](https://github.com/gaearon) in [#24459](https://github.com/facebook/react/pull/24459))

### React DOM Server

* Pass information about server errors to the client. ([@salazarm](https://github.com/salazarm) and [@gnoff](https://github.com/gnoff) in [#24551](https://github.com/facebook/react/pull/24551) and [#24591](https://github.com/facebook/react/pull/24591))
* Allow to provide a reason when aborting the HTML stream. ([@gnoff](https://github.com/gnoff) in [#24680](https://github.com/facebook/react/pull/24680))
* Eliminate extraneous text separators in the HTML where possible. ([@gnoff](https://github.com/gnoff) in [#24630](https://github.com/facebook/react/pull/24630))
* Disallow complex children inside `<title>` elements to match the browser constraints. ([@gnoff](https://github.com/gnoff) in [#24679](https://github.com/facebook/react/pull/24679))
* Fix buffering in some worker environments by explicitly setting `highWaterMark` to `0`. ([@jplhomer](https://github.com/jplhomer) in [#24641](https://github.com/facebook/react/pull/24641))
