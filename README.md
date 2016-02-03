# Encryption Library

This is a small encryption library that I've developed, and also my first.

The encryption library is built on the concept of Caesar cipher, with added complexity. From Wikipedia ( It is a type of substitution cipher in which each letter in the plaintext is replaced by a letter some fixed number of positions down the alphabet. For example, with a left shift of 3, D would be replaced by A, E would become B, and so on.)

The library takes a key, and converts it to a numerical seed which is then fed into the Random class. Then we generate a list of 'shifts'. For example, the random numbers generated could be 34, 2 and 100. Because of the seed being set, as long as the key is the same, the shifts will be the same. In order to encrypt we simply apply the 1st shift to the 1st character, 2nd to the 2nd, etc. Some of the shifts may move the character id over 255 (which is over the limits of a byte), so will be looped back around. IE, 255 + 1 -> 0.

To decrypt we simply take the string and move the characters backwards, simply the inverse of the encrypting process.

Note: I don't guarantee complete security of this library, it is only a simple execution of an idea.

Visit my portfolio at http://jamorris.co.uk/
