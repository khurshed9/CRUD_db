using CRUD_exam.Models;

namespace CRUD_exam.Services;

public interface IOwnerService
{
    List<Owner> GetOwners();

    Owner GetOwnerById(int id);

    bool CreatOwner(Owner owner);

    bool UpdateOwner(Owner owner);

    bool DeleteOwnerById(int id);
}