﻿using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;

namespace SportEvents.Application.Contracts;
public interface IOrganizerService
{
    IList<OrganizerResponse> GetOrganizers();

    IList<OrganizerResponse> GetOrganizersByEventId(int eventId);

    OrganizerResponse? GetOrganizerById(int organizerId);

    bool CreateOrganizer(OrganizerCreateRequest request);

    bool UpdateOrganizer(OrganizerUpdateRequest request);

    bool DeleteOrganizer(int organizerId);
}
