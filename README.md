# URL Shortener (C#)

An interactive URL shortener CLI app. for [bit.ly](https://bitly.com/).
Implemented in C#, using bit.ly's API v4.

It was tested under Linux and Windows.

## Usage

```bash
$ ./UrlShortener
Long URL: https://google.com

https://bit.ly/2R9zFOR

# expanded from shortened URL: https://google.com (matches)
```

## Build

Compile and run:

```bash
$ dotnet run
```

Make a framework-dependent deployment:

```bash
$ dotnet publish -o dist -c Release
```

## Pre-requisite

For this to work, you need an access token from bit.ly. Don't worry, it's free.
After registration you can generate one for yourself. Then, add it as an
environment variable called `BITLY_ACCESS_TOKEN`. For instance, under Linux
add the following line to the end of your `~/.bashrc` file:

```bash
export BITLY_ACCESS_TOKEN="..."
```

## Related projects

* I used [pyshorteners](https://github.com/ellisonleao/pyshorteners/blob/master/pyshorteners/shorteners/bitly.py) to figure out how to call bit.ly's API v4.

* I have a [Nim implementation](https://github.com/jabbalaci/UrlShortener-nim) but that one uses an older API of bit.ly (v3).

* I have a [Rust implementation](https://github.com/jabbalaci/UrlShortener-rs) too, which uses the newer API of bit.ly (v4).
