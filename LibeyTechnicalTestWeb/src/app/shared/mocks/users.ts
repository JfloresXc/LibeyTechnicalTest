import { LibeyUser } from "src/app/features/users/models/libeyuser";

export const usersMock: LibeyUser[] = [
    {
        documentNumber: "12345678",
        documentTypeId: 1,
        name: "Juan",
        fathersLastName: "Pérez",
        mothersLastName: "Gómez",
        address: "Av. Principal 123",
        regionCode: "15",
        provinceCode: "01",
        ubigeoCode: "150101",
        phone: "987654321",
        email: "juan.perez@example.com",
        password: "securePassword123",
        active: true
    },
    {
        documentNumber: "87654321",
        documentTypeId: 2,
        name: "María",
        fathersLastName: "López",
        mothersLastName: "Fernández",
        address: "Calle Secundaria 456",
        regionCode: "07",
        provinceCode: "02",
        ubigeoCode: "070201",
        phone: "912345678",
        email: "maria.lopez@example.com",
        password: "password123",
        active: false
    },
    {
        documentNumber: "11223344",
        documentTypeId: 1,
        name: "Carlos",
        fathersLastName: "Ramírez",
        mothersLastName: "Díaz",
        address: "Jr. Central 789",
        regionCode: "03",
        provinceCode: "04",
        ubigeoCode: "030401",
        phone: "965874123",
        email: "carlos.ramirez@example.com",
        password: "MyPass@456",
        active: true
    },
    {
        documentNumber: "44556677",
        documentTypeId: 1,
        name: "Lucía",
        fathersLastName: "Martínez",
        mothersLastName: "Torres",
        address: "Pasaje Los Cedros 321",
        regionCode: "12",
        provinceCode: "03",
        ubigeoCode: "120301",
        phone: "954123789",
        email: "lucia.martinez@example.com",
        password: "Secret123!",
        active: true
    },
    {
        documentNumber: "99887766",
        documentTypeId: 2,
        name: "Pedro",
        fathersLastName: "González",
        mothersLastName: "Vargas",
        address: "Urbanización Sol 654",
        regionCode: "05",
        provinceCode: "06",
        ubigeoCode: "050601",
        phone: "923456789",
        email: "pedro.gonzalez@example.com",
        password: "Pedro2024",
        active: false
    }
];
