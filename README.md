# Named Enum
An alternative to raw enums for Unity that serializes the enum name along with
its numeric value.

This makes it possible to reorder enums without breaking existing Unity assets,
including adding new values between existing ones.
Thus they are resistant to code merges where both branches add new values to
the enum.


## Installing the package
Install using [Unity Package Manager](https://docs.unity3d.com/Manual/Packages.html)
adding a package [using this git repository URL](https://docs.unity3d.com/Manual/upm-ui-giturl.html):

    https://github.com/gilzoide/NamedEnum.git


## Similar projects
- https://github.com/dotsquid/StableEnum
