# EmptyParcelLocker.API

## Models

---

### ParcelLocker

| Field     | Type     | Description                         |
|-----------|----------|-------------------------------------|
| Id        | Guid     | ParcelLocker Id                     |
| Name      | string   | ParcelLocker name                   |
| Lockers   | Locker[] | array of parcel-locker's lockers id |
| AddressId | Guid     | id of parcel-locker's address       |
| Address   | Address  |                                     |

---

### Locker

| Field          | Type         | Description                                 |
|----------------|--------------|---------------------------------------------|
| Id             | Guid         | Locker id                                   |
| IsEmpty        | bool         | describes if locker is empty                |
| ParcelLockerId | Guid         | parcelLocker's id that contains this locker |
| ParcelLocker   | ParcelLocker |                                             |
| LockerTypeId   | Guid         | id of locker type                           |
| LockerType     | LockerType   |                                             |

---

### ParcelLockerAddress

| Field           | Type         | Description                              |
|-----------------|--------------|------------------------------------------|
| Id              | Guid         | address id                               |
| Street          | string       | eg. Kasztanowa                           |
| StreetNumber    | string       | eg. 38                                   |
| ApartmentNumber | string       | eg. u8                                   |
| ZipCode         | string       | eg. 00-000                               |
| CityName        | string       | eg. Warsaw                               |
| ParcelLockerId  | Guid         | id of parcel locker at specified address |
| ParcelLocker    | ParcelLocker |                                          |

---

### LockerType

| Field     | Type   | Description                                                     |
|-----------|--------|-----------------------------------------------------------------|
| Id        | Guid   | locker type id                                                  |
| Name      | string | locker type name                                                |
| MaxHeight | number | maximum height of packet in this type of locker described in mm |
| MaxWidth  | number | maximum width of packet in this type of locker described in mm  |
| MaxLength | number | maximum length of packet in this type of locker described in mm |
| MaxWeight | number | maximum weight of packet in this type of locker described in kg |

## Endpoints

### ParcelLocker

> **GET** _/parcelLocker_

Get parcel locker list from database

> **GET** _/parcelLocker/{parcelLockerId}_

Get specified parcel locker from database

> **PUT** _/parcelLocker/{parcelLocker}_

Update parcel locker.

### Locker

> **GET** _/locker_

Get lockers list from database.

> **GET** _/locker/{lockerId}_

Get specified locker.

> **PUT** _/locker/{lockerId}_

Updates locker of specified id

### LockerType

> **GET** _/lockerType_

Get locker types.

> **GET** _/lockerType/{lockerTypeId}_

Get specified locker type.

### ParcelLockerAddress

> **GET** _/address_

Get addresses.

> **GET** _/address/{addressId}_

Get specified address
